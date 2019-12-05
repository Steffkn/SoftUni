using Newtonsoft.Json;

namespace SoftJail.DataProcessor.ImportDto
{
    public class DepartmentImportDTO
    {
        public string Name { get; set; }
        
        public CellImportDTO[] Cells { get; set; }
    }

    public class CellImportDTO
    {
        public int CellNumber { get; set; }

        public bool HasWindow { get; set; }
    }
}
