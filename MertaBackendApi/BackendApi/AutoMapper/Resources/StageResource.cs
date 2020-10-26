using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApi.AutoMapper.Resources
{
    public class StageResource
    {
    }
    public class StageCreateDto
    {
        public string Stage_Tag { get; set; }
    }
    public class StageGetDto
    {
        public short Stage_Id { get; set; }
        public string Stage_Tag { get; set; }
    }
}
