namespace ClassifiedAds.Helpers
{
    public class FileUploadHelper
    {
        public static bool TryUpload(IFormFile file, string directory, out string result)
        {
            if (file == null || file.Length == 0)
            {
                result = "File must be uploaded";
                return false;
            }

            var ext = Path.GetExtension(file.FileName).ToLower().TrimStart('.');
            if (!Globals.SafeExtensionForUpload.Contains(ext))
            {
                result = $"{ext} extsion not allowed. Only {string.Join(", ", Globals.SafeExtensionForUpload)} extensions are allowed";
                return false;
            }

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", directory);

            Directory.CreateDirectory(uploadsFolder);

            var fileName = Guid.NewGuid().ToString() + "." + ext;
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (FileStream fs = new(filePath, FileMode.Create))
            {
                file.CopyTo(fs);
            }

            result = $"/{directory}/" + fileName;
            return true;
        }
    }
}
