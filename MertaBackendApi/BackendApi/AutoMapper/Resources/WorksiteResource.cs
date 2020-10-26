using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApi.AutoMapper.Resources
{
    public class WorksiteResource
    {

    }

    public class WorksiteCreateDto
    {

        public string Worksite_Tag { get; set; }        
        public string Worksite_City { get; set; }       
        public string Worksite_Adress { get; set; }     
        public DateTime Worksite_SDate { get; set; }    
        public DateTime Worksite_FDate { get; set; }    
        public short WorksiteStage_Id { get; set; }     
        public short WorksiteCategory_Id { get; set; }   
    }
    public class WorksiteGetDto
    {
        public short Worksite_Id { get; set; }
        public string Worksite_Tag { get; set; }
        public string Worksite_City { get; set; }
        public string Worksite_Adress { get; set; }
        public DateTime Worksite_SDate { get; set; }
        public DateTime Worksite_FDate { get; set; }
        public short WorksiteStage_Id { get; set; }
        public short WorksiteCategory_Id { get; set; }
    }
}
