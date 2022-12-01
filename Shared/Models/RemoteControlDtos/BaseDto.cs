using SODesk.Shared.Enums;
using System.Runtime.Serialization;

namespace SODesk.Shared.Models.RemoteControlDtos
{
    [DataContract]
    public class BaseDto
    {
        [DataMember(Name = "DtoType")]
        public virtual BaseDtoType DtoType { get; init; }
    }
}
