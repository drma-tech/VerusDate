using System;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Model
{
    public class ProfileReportModel
    {
        public DateTime DtInsert { get; set; } = DateTime.UtcNow;
        public ReportType Type { get; set; }
    }
}