﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.DTO
{
    public class TableDTO
    {
        public Guid TableId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public Guid AreaId { get; set; }

        public TableDTO(DataRow row)
        {
            TableId = Guid.Parse(row["TableId"].ToString());
            Name = row["Name"].ToString();
            Description = row["Description"].ToString();
            if (int.TryParse(row["Status"].ToString(), out int status))
            {
                Status = status;
            }
            else
            { 
                Status = 0;
            }
            AreaId = Guid.Parse(row["AreaId"].ToString());
        }
    }
}