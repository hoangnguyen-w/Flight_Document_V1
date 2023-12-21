using Flight_Document_V1.DTO;
using Flight_Document_V1.Entity;
using Flight_Document_V1.IService;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
#nullable disable

namespace Flight_Document_V1.Service
{
    public class DocumentService : IDocumentService
    {
        private Document document;
        private readonly FlightManagerContext _context;

        public DocumentService(FlightManagerContext context)
        {
            _context = context;
        }

        public async Task<List<Document>> GetAll()
        {
            var list = await _context.Documents
                .Include(d => d.Groups)
                .Include(d => d.Flight)
                .ToListAsync();
            return list;
        }

        public async Task<List<Document>> FindByID(int id)
        {
            var list = await _context.Documents
                .Include(d => d.Groups)
                .Include(d => d.Flight)
                .Where(d => d.DocumentID == id).ToListAsync();
            return list;
        }

        public async Task<Document> FindIDToResult(int id)
        {
            var list = await _context.Documents.FindAsync(id);
            return list;
        }

        public async Task CreateDocument(DocumentDTO documentDTO, IFormFile file)
        {
            document = new Document();

            /*string filename = "";

            var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
            filename = file + extension;

            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\FilePDF");

            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }*/

            var exactpath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\FilePDF", file.FileName);
            using (var stream = new FileStream(exactpath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }


            document.DocumentName = documentDTO.DocumentName;
            document.Note = documentDTO.Note;
            document.Version = 1.0;
            document.DocumentFile = file.FileName;
            document.CreateDateDocument = DateTime.Now;
            document.DocumentTypeID = documentDTO.documentType;
            document.FlightNo = documentDTO.FlightNo;

            _context.Documents.Add(document);
            await _context.SaveChangesAsync();

            /*int searchID = _context.Documents.Select(d => d.DocumentID)
                                             .Where(document.DocumentName == documentDTO.DocumentName);
            History history = new History();
            history.DocumentID = searchID;
            history.HistoryDate = DateTime.Now;
            history.DocumentHistory = file.FileName;

            _context.Histories.Add(history);
            await _context.SaveChangesAsync();*/

        }

        public async Task EditDocument(int id, IFormFile file)
        {
            //string filename = "";

            /*var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
            filename = DateTime.Now.Ticks.ToString() + extension;

            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\FilePDF");*/
            var exactpath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\FilePDF", file.FileName);
            using (var stream = new FileStream(exactpath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var doc = await _context.Documents.FirstOrDefaultAsync(d => d.DocumentID == id);
            //double SumVersion = RoundUpVersion(doc.Version);
            //doc.Version = SumVersion;
            doc.Version += 0.1;
            doc.UpdateDateDocument = DateTime.Now;
            doc.DocumentFile = file.FileName;

            History history = new History();
            history.DocumentID = id;
            history.HistoryDate = DateTime.Now;
            history.DocumentHistory = file.FileName;

            _context.Documents.Update(doc);
            _context.Histories.Add(history);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDocument(int id)
        {
            var doc = _context.Documents.FirstOrDefault(d => d.DocumentID == id);
            _context.Remove(doc);
            await _context.SaveChangesAsync();
        }


        public double RoundUpVersion(double version)
        {
            // Kiểm tra phần thập phân, nếu lớn hơn hoặc bằng 0.10 thì làm tròn lên
            if (version % 1.0 >= 0.9)
            {
                return Math.Ceiling(version);
            }
            else
            {
                return RoundUpVersion(version + 0.1);
            }
        }

        public async Task<(byte[], string, string)> DownloadFileDocument(int id)
        {
            var search = _context.Documents.FirstOrDefault(d => d.DocumentID == id);

            if(search != null)
            {
                string filename = search.DocumentFile;

                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\FilePDF", filename);

                var provider = new FileExtensionContentTypeProvider();
                if (!provider.TryGetContentType(filepath, out var contenttype))
                {
                    contenttype = "application/octet-stream";
                }

                var bytes = await System.IO.File.ReadAllBytesAsync(filepath);
                return (bytes, contenttype, Path.GetFileName(filepath));
            }
            throw new Exception("404 Not Found DocumentID");
        }
    }      
}
