#!/bin/bash
HostName=
Organization=
GUID=$(cat /proc/sys/kernel/random/uuid)
UpdatePackagePath=""


Args=( "$@" )
ArgLength=${#Args[@]}

for (( i=0; i<${ArgLength}; i+=2 ));
do
    if [ "${Args[$i]}" = "--uninstall" ]; then
        systemctl stop remotely-agent
        rm -r -f /usr/local/bin/SODesk
        rm -f /etc/systemd/system/remotely-agent.service
        systemctl daemon-reload
        exit
    elif [ "${Args[$i]}" = "--path" ]; then
        UpdatePackagePath="${Args[$i+1]}"
    fi
done

UbuntuVersion=$(lsb_release -r -s)

wget -q https://packages.microsoft.com/config/ubuntu/$UbuntuVersion/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
dpkg -i packages-microsoft-prod.deb
apt-get update
apt-get -y install apt-transport-https
apt-get update
apt-get -y install dotnet-runtime-6.0
rm packages-microsoft-prod.deb

apt-get -y install libx11-dev
apt-get -y install libxrandr-dev
apt-get -y install unzip
apt-get -y install libc6-dev
apt-get -y install libgdiplus
apt-get -y install libxtst-dev
apt-get -y install xclip
apt-get -y install jq
apt-get -y install curl


if [ -f "/usr/local/bin/SODesk/ConnectionInfo.json" ]; then
    SavedGUID=`cat "/usr/local/bin/SODesk/ConnectionInfo.json" | jq -r '.DeviceID'`
     if [[ "$SavedGUID" != "null" && -n "$SavedGUID" ]]; then
        GUID="$SavedGUID"
    fi
fi

rm -r -f /usr/local/bin/SODesk
rm -f /etc/systemd/system/remotely-agent.service

mkdir -p /usr/local/bin/SODesk/
cd /usr/local/bin/SODesk/

if [ -z "$UpdatePackagePath" ]; then
    echo  "Downloading client..." >> /tmp/SODesk_Install.log
    wget $HostName/Content/SODesk-Linux.zip
else
    echo  "Copying install files..." >> /tmp/SODesk_Install.log
    cp "$UpdatePackagePath" /usr/local/bin/SODesk/SODesk-Linux.zip
    rm -f "$UpdatePackagePath"
fi

unzip ./SODesk-Linux.zip
rm -f ./SODesk-Linux.zip
chmod +x ./SODesk_Agent
chmod +x ./Desktop/SODesk_Desktop


connectionInfo="{
    \"DeviceID\":\"$GUID\", 
    \"Host\":\"$HostName\",
    \"OrganizationID\": \"$Organization\",
    \"ServerVerificationToken\":\"\"
}"

echo "$connectionInfo" > ./ConnectionInfo.json

curl --head $HostName/Content/SODesk-Linux.zip | grep -i "etag" | cut -d' ' -f 2 > ./etag.txt

echo Creating service... >> /tmp/SODesk_Install.log

serviceConfig="[Unit]
Description=The SODesk agent used for remote access.

[Service]
WorkingDirectory=/usr/local/bin/SODesk/
ExecStart=/usr/local/bin/SODesk/SODesk_Agent
Restart=always
StartLimitIntervalSec=0
RestartSec=10

[Install]
WantedBy=graphical.target"

echo "$serviceConfig" > /etc/systemd/system/remotely-agent.service

systemctl enable remotely-agent
systemctl restart remotely-agent

echo Install complete. >> /tmp/SODesk_Install.log
