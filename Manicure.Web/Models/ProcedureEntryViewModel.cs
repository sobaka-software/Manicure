﻿using System;

namespace Manicure.Web.Models
{
    public class ProcedureEntryViewModel
    {
        public int ProcedureId { get; set; }

        public int MasterId { get; set; }

        public DateTime Date { get; set; }

        public DateTime StartTime { get; set; }
    }
}