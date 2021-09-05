namespace Shop.Application.Services.Dtos
{
    using System;
    using System.Collections.Generic;
    using EventCloud;
    //layui tree checkbox tree
    public class TreeOutput
    {
        public String Title{get;set;}
        public long? Id{get;set;}
        public String Field{get;set;}
        public String Href{get;set;}
        //checked 
        public bool Disabled{get;set;}
        public List<TreeOutput> Children{get;set;}
        //tree expand
        public bool Spread{get;set;}
    }

    public class TreeDto
    {
        
    }
}