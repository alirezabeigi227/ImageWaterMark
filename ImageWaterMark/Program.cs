//using OfficeOpenXml;
//using System.Drawing;
//using System.Drawing.Text;

//public class Program
//{
//    private static void Main(string[] args)
//    {
//        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

//        string outputDir = Path.Combine(AppContext.BaseDirectory, "NewImage");
//        string excelPath = Path.Combine(AppContext.BaseDirectory, "branches.xlsx");
//        string imagePath = Path.Combine(AppContext.BaseDirectory, "Assets", "template.png");
//        string fontPath = Path.Combine(AppContext.BaseDirectory, "Assets", "font.ttf");


//        // بررسی وجود فایل‌ها
//        if (!File.Exists(excelPath))
//        {
//            Console.WriteLine("فایل اکسل پیدا نشد!");
//            return;
//        }

//        if (!File.Exists(imagePath))
//        {
//            Console.WriteLine("فایل قالب تصویر پیدا نشد!");
//            return;
//        }

//        if (!File.Exists(fontPath))
//        {
//            Console.WriteLine("فایل فونت پیدا نشد!");
//            return;
//        }

//        Directory.CreateDirectory(outputDir);

//        using var package = new ExcelPackage(new FileInfo(excelPath));

//        if (package.Workbook.Worksheets.Count == 0)
//        {
//            Console.WriteLine("هیچ شیتی در فایل اکسل وجود ندارد!");
//            return;
//        }

//        var sheet = package.Workbook.Worksheets[0];
//        if (sheet.Dimension == null)
//        {
//            Console.WriteLine("شیت خالی است!");
//            return;
//        }

//        int rows = sheet.Dimension.End.Row;

//        PrivateFontCollection fontCollection = new();
//        fontCollection.AddFontFile(fontPath);

//        Font font = new Font(
//            fontCollection.Families[0],
//            40,
//            System.Drawing.FontStyle.Bold
//        );

//        Brush brush = new SolidBrush(Color.FromArgb(255, 0, 40, 120));

//        for (int i = 2; i <= rows; i++) // ردیف اول عنوان است
//        {
//            string branchCode = sheet.Cells[i, 1].Text.Trim();
//            string branchName = sheet.Cells[i, 2].Text.Trim();

//            if (string.IsNullOrWhiteSpace(branchCode) || string.IsNullOrWhiteSpace(branchName))
//            {
//                Console.WriteLine($"ردیف {i} خالی است، رد شد.");
//                continue;
//            }

//            Console.WriteLine($"در حال ساخت تصویر: {branchName} کد {branchCode}");

//            using var bmp = new Bitmap(imagePath);
//            using Graphics g = Graphics.FromImage(bmp);

//            g.TextRenderingHint = TextRenderingHint.AntiAlias;

//            string text = $"{branchName} کد {branchCode}";

//            float x = 300;
//            float y = 420;

//            g.DrawString(text, font, brush, x, y);

//            string safeBranchName = string.Concat(branchName.Split(Path.GetInvalidFileNameChars()));
//            string outputPath = Path.Combine(outputDir, $"{safeBranchName}_{branchCode}.png");

//            bmp.Save(outputPath);
//        }

//        Console.WriteLine("تمام تصاویر با موفقیت ساخته شدند!");
//        Console.WriteLine($"بررسی کنید پوشه خروجی: {Path.GetFullPath(outputDir)}");
//    }
//}
/////////////////Version2//////////////////////////////////


//using OfficeOpenXml;
//using System.Drawing;
//using System.Drawing.Text;
//using System.Text;

//public class Program
//{
//    private static void Main(string[] args)
//    {
//        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

//        string outputDir = Path.Combine(AppContext.BaseDirectory, "NewImage");
//        string excelPath = Path.Combine(AppContext.BaseDirectory, "branches1800.xlsx");
//        string imagePath = Path.Combine(AppContext.BaseDirectory, "Assets", "template.png");
//        string fontPath = Path.Combine(AppContext.BaseDirectory, "Assets", "font.ttf");

//        if (!File.Exists(excelPath)) { Console.WriteLine("فایل اکسل پیدا نشد!"); return; }
//        if (!File.Exists(imagePath)) { Console.WriteLine("فایل قالب تصویر پیدا نشد!"); return; }
//        if (!File.Exists(fontPath)) { Console.WriteLine("فایل فونت پیدا نشد!"); return; }

//        Directory.CreateDirectory(outputDir);

//        using var package = new ExcelPackage(new FileInfo(excelPath));
//        if (package.Workbook.Worksheets.Count == 0) { Console.WriteLine("هیچ شیتی در فایل اکسل وجود ندارد!"); return; }

//        var sheet = package.Workbook.Worksheets[0];
//        if (sheet.Dimension == null) { Console.WriteLine("شیت خالی است!"); return; }

//        int rows = sheet.Dimension.End.Row;

//        // بارگذاری فونت
//        PrivateFontCollection fontCollection = new();
//        fontCollection.AddFontFile(fontPath);
//        Font font = new Font(fontCollection.Families[0], 19, FontStyle.Bold);

//        Brush brush = new SolidBrush(Color.FromArgb(255, 5, 30, 100));

//        float marginRight = 95; // فاصله به راست از وسط
//        float marginBottom = 110; // فاصله به پایین از وسط

//        for (int i = 2; i <= rows; i++)
//        {
//            string branchCode = sheet.Cells[i, 1].Text.Trim();
//            string branchName = sheet.Cells[i, 2].Text.Trim();

//            if (string.IsNullOrWhiteSpace(branchCode) || string.IsNullOrWhiteSpace(branchName))
//            {
//                Console.WriteLine($"ردیف {i} خالی است، رد شد.");
//                continue;
//            }

//            Console.WriteLine($"در حال ساخت تصویر: شعبه {branchName} کد {branchCode}");

//            using var bmp = new Bitmap(imagePath);
//            using Graphics g = Graphics.FromImage(bmp);
//            g.TextRenderingHint = TextRenderingHint.AntiAlias;

//            string text = $"شعبه {branchName} کد {branchCode}";


//            float maxWidth = bmp.Width - 20;
//            Font drawFont = font;
//            SizeF textSize = g.MeasureString(text, drawFont);

//            while (textSize.Width > maxWidth && drawFont.Size > 10)
//            {
//                drawFont = new Font(drawFont.FontFamily, drawFont.Size - 1, drawFont.Style);
//                textSize = g.MeasureString(text, drawFont);
//            }

//            // محاسبه مرکز متن با margin
//            float x = (bmp.Width - textSize.Width) / 2 + marginRight;
//            float y = (bmp.Height - textSize.Height) / 2 + marginBottom;


//            for (int dx = 0; dx <= 1; dx++)
//            {
//                for (int dy = 0; dy <= 1; dy++)
//                {
//                    g.DrawString(text, drawFont, brush, x + dx, y + dy);
//                }
//            }

//            string safeBranchName = string.Concat(branchName.Split(Path.GetInvalidFileNameChars()));
//            string outputPath = Path.Combine(outputDir, $"{safeBranchName}_{branchCode}.png");

//            bmp.Save(outputPath);
//        }

//        Console.WriteLine("تمام تصاویر با موفقیت ساخته شدند!");
//        Console.WriteLine($"بررسی کنید پوشه خروجی: {Path.GetFullPath(outputDir)}");
//    }
//}

//////////////////Version3///////////////////////////////////////////\\
///// بیشتر از 20 کیلو بایت


//using OfficeOpenXml;
//using System.Drawing;
//using System.Drawing.Text;
//using System.IO;
//using System.Text;

//public class Program
//{
//    private static void Main(string[] args)
//    {
//        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

//        string outputDir = Path.Combine(AppContext.BaseDirectory, "NewImage");
//        string excelPath = Path.Combine(AppContext.BaseDirectory, "branches1800.xlsx");
//        string imagePath = Path.Combine(AppContext.BaseDirectory, "Assets", "template.png");
//        string fontPath = Path.Combine(AppContext.BaseDirectory, "Assets", "font.ttf");
//        string csvPath = Path.Combine(outputDir, "Base64Images.csv");

//        if (!File.Exists(excelPath)) { Console.WriteLine("فایل اکسل پیدا نشد!"); return; }
//        if (!File.Exists(imagePath)) { Console.WriteLine("فایل قالب تصویر پیدا نشد!"); return; }
//        if (!File.Exists(fontPath)) { Console.WriteLine("فایل فونت پیدا نشد!"); return; }

//        Directory.CreateDirectory(outputDir);

//        using var package = new ExcelPackage(new FileInfo(excelPath));
//        if (package.Workbook.Worksheets.Count == 0) { Console.WriteLine("هیچ شیتی در فایل اکسل وجود ندارد!"); return; }

//        var sheet = package.Workbook.Worksheets[0];
//        if (sheet.Dimension == null) { Console.WriteLine("شیت خالی است!"); return; }

//        int rows = sheet.Dimension.End.Row;

//        // بارگذاری فونت
//        PrivateFontCollection fontCollection = new();
//        fontCollection.AddFontFile(fontPath);
//        Brush brush = new SolidBrush(Color.FromArgb(255, 5, 30, 100));

//        float marginBottom = 110;
//        float maxFontSize = 26;
//        float minFontSize = 16;
//        float rightPadding = 20;


//        var csvBuilder = new StringBuilder();
//        csvBuilder.AppendLine("BranchCode,BranchName,Base64Image");

//        for (int i = 2; i <= rows; i++)
//        {
//            string branchCode = sheet.Cells[i, 1].Text.Trim();
//            string branchName = sheet.Cells[i, 2].Text.Trim();

//            if (string.IsNullOrWhiteSpace(branchCode) || string.IsNullOrWhiteSpace(branchName))
//            {
//                Console.WriteLine($"ردیف {i} خالی است، رد شد.");
//                continue;
//            }

//            Console.WriteLine($"در حال ساخت تصویر: شعبه {branchName} کد {branchCode}");

//            using var bmp = new Bitmap(imagePath);
//            using Graphics g = Graphics.FromImage(bmp);
//            g.TextRenderingHint = TextRenderingHint.AntiAlias;

//            string text = $"شعبه {branchName} کد {branchCode}";

//            float maxWidth = bmp.Width - 2 * rightPadding;
//            float fontSize = maxFontSize;
//            Font drawFont = new Font(fontCollection.Families[0], fontSize, FontStyle.Bold);
//            SizeF textSize = g.MeasureString(text, drawFont);

//            while (textSize.Width > maxWidth && fontSize > minFontSize)
//            {
//                fontSize -= 1f;
//                drawFont = new Font(fontCollection.Families[0], fontSize, FontStyle.Bold);
//                textSize = g.MeasureString(text, drawFont);
//            }


//            float x = bmp.Width - rightPadding - textSize.Width;
//            float y = (bmp.Height - textSize.Height) / 2 + marginBottom;

//            for (int dx = 0; dx <= 1; dx++)
//            {
//                for (int dy = 0; dy <= 1; dy++)
//                {
//                    g.DrawString(text, drawFont, brush, x + dx, y + dy);
//                }
//            }

//            string safeBranchName = string.Concat(branchName.Split(Path.GetInvalidFileNameChars()));
//            string outputPath = Path.Combine(outputDir, $"{safeBranchName}_{branchCode}.png");

//            bmp.Save(outputPath);

//            using var ms = new MemoryStream();
//            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
//            string base64 = Convert.ToBase64String(ms.ToArray());

//            string csvLine = $"\"{branchCode}\",\"{branchName}\",\"{base64}\"";
//            csvBuilder.AppendLine(csvLine);
//        }

//        File.WriteAllText(csvPath, csvBuilder.ToString(), Encoding.UTF8);

//        Console.WriteLine("تمام تصاویر و Base64ها با موفقیت ساخته شدند!");
//        Console.WriteLine($"بررسی کنید پوشه خروجی: {Path.GetFullPath(outputDir)}");
//        Console.WriteLine($"فایل CSV Base64 در مسیر: {Path.GetFullPath(csvPath)}");
//    }
//}


///////////////////////Version4/////////////////////////////////
/// کمتر تز 20 کیلو بایت
/// ورژن اصلی مورد استفاده



//using OfficeOpenXml;
//using System.Drawing;
//using System.Drawing.Text;
//using System.IO;
//using System.Text;

//public class Program
//{
//    private static void Main(string[] args)
//    {
//        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

//        string outputDir = Path.Combine(AppContext.BaseDirectory, "NewImage");
//        string excelPath = Path.Combine(AppContext.BaseDirectory, "branches1800.xlsx");
//        string imagePath = Path.Combine(AppContext.BaseDirectory, "Assets", "template.png");
//        string fontPath = Path.Combine(AppContext.BaseDirectory, "Assets", "font.ttf");
//        string csvPath = Path.Combine(outputDir, "Base64Images.csv");

//        if (!File.Exists(excelPath)) { Console.WriteLine("فایل اکسل پیدا نشد!"); return; }
//        if (!File.Exists(imagePath)) { Console.WriteLine("فایل قالب تصویر پیدا نشد!"); return; }
//        if (!File.Exists(fontPath)) { Console.WriteLine("فایل فونت پیدا نشد!"); return; }

//        Directory.CreateDirectory(outputDir);

//        using var package = new ExcelPackage(new FileInfo(excelPath));
//        if (package.Workbook.Worksheets.Count == 0) { Console.WriteLine("هیچ شیتی در فایل اکسل وجود ندارد!"); return; }

//        var sheet = package.Workbook.Worksheets[0];
//        if (sheet.Dimension == null) { Console.WriteLine("شیت خالی است!"); return; }

//        int rows = sheet.Dimension.End.Row;


//        PrivateFontCollection fontCollection = new();
//        fontCollection.AddFontFile(fontPath);
//        Brush brush = new SolidBrush(Color.FromArgb(255, 5, 30, 100));

//        float marginBottom = 110;
//        float maxFontSize = 26;
//        float minFontSize = 16;
//        float rightPadding = 20;

//        var csvBuilder = new StringBuilder();
//        csvBuilder.AppendLine("BranchCode,BranchName,Base64Image");

//        for (int i = 2; i <= rows; i++)
//        {
//            string branchCode = sheet.Cells[i, 1].Text.Trim();
//            string branchName = sheet.Cells[i, 2].Text.Trim();

//            if (string.IsNullOrWhiteSpace(branchCode) || string.IsNullOrWhiteSpace(branchName))
//            {
//                Console.WriteLine($"ردیف {i} خالی است، رد شد.");
//                continue;
//            }

//            Console.WriteLine($"در حال ساخت تصویر: شعبه {branchName} کد {branchCode}");

//            using var bmp = new Bitmap(imagePath);
//            using Graphics g = Graphics.FromImage(bmp);
//            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

//            string text = $"شعبه {branchName} کد {branchCode}";
//            float maxWidth = bmp.Width - 2 * rightPadding;
//            float fontSize = maxFontSize;
//            Font drawFont = new Font(fontCollection.Families[0], fontSize, FontStyle.Bold);
//            SizeF textSize = g.MeasureString(text, drawFont);

//            while (textSize.Width > maxWidth && fontSize > minFontSize)
//            {
//                fontSize -= 1f;
//                drawFont = new Font(fontCollection.Families[0], fontSize, FontStyle.Bold);
//                textSize = g.MeasureString(text, drawFont);
//            }

//            float x = bmp.Width - rightPadding - textSize.Width;
//            float y = (bmp.Height - textSize.Height) / 2 + marginBottom;

//            for (int dx = 0; dx <= 1; dx++)
//            {
//                for (int dy = 0; dy <= 1; dy++)
//                {
//                    g.DrawString(text, drawFont, brush, x + dx, y + dy);
//                }
//            }

//            string safeBranchName = string.Concat(branchName.Split(Path.GetInvalidFileNameChars()));
//            string outputPath = Path.Combine(outputDir, $"{safeBranchName}_{branchCode}.png");


//            using var ms = new MemoryStream();
//            Bitmap tempBmp = new Bitmap(bmp);
//            int scale = 100;
//            int targetSize = 20 * 1024;

//            while (true)
//            {
//                ms.SetLength(0);
//                tempBmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

//                if (ms.Length <= targetSize || scale <= 10)
//                    break;

//                scale -= 10;
//                int newWidth = tempBmp.Width * scale / 100;
//                int newHeight = tempBmp.Height * scale / 100;
//                var scaledBmp = new Bitmap(tempBmp, newWidth, newHeight);
//                tempBmp.Dispose();
//                tempBmp = scaledBmp;
//            }

//            // insert to db
//            File.WriteAllBytes(outputPath, ms.ToArray());

//            string base64 = Convert.ToBase64String(ms.ToArray());
//            string csvLine = $"\"{branchCode}\",\"{branchName}\",\"data:image/png;base64,{base64}\"";
//            csvBuilder.AppendLine(csvLine);
//        }

//        File.WriteAllText(csvPath, csvBuilder.ToString(), Encoding.UTF8);

//        Console.WriteLine("تمام تصاویر و Base64ها با موفقیت ساخته شدند!");
//        Console.WriteLine($"بررسی کنید پوشه خروجی: {Path.GetFullPath(outputDir)}");
//        Console.WriteLine($"فایل CSV Base64 در مسیر: {Path.GetFullPath(csvPath)}");
//    }
//}

/////////////////////////////////Version5  ----->> Insert In db With ConnectionString  (Dapper in Asp .Net) /////////////////

using OfficeOpenXml;
using System.Drawing;
using System.Drawing.Text;
using Dapper;
using Microsoft.Data.SqlClient;


public class Program
{
    private static void Main(string[] args)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        string excelPath = Path.Combine(AppContext.BaseDirectory, "branches1800.xlsx");
        string imagePath = Path.Combine(AppContext.BaseDirectory, "Assets", "template.png");
        string fontPath = Path.Combine(AppContext.BaseDirectory, "Assets", "font.ttf");

        if (!File.Exists(excelPath)) { Console.WriteLine("فایل اکسل پیدا نشد"); return; }
        if (!File.Exists(imagePath)) { Console.WriteLine("قالب تصویر پیدا نشد"); return; }
        if (!File.Exists(fontPath)) { Console.WriteLine("فونت پیدا نشد"); return; }

        using var package = new ExcelPackage(new FileInfo(excelPath));
        var sheet = package.Workbook.Worksheets[0];
        int rows = sheet.Dimension.End.Row;

        PrivateFontCollection fontCollection = new();
        fontCollection.AddFontFile(fontPath);
        Brush brush = new SolidBrush(Color.FromArgb(255, 5, 30, 100));

        float marginBottom = 110;
        float maxFontSize = 26;
        float minFontSize = 16;
        float rightPadding = 20;
        int targetSize = 20 * 1024; // تقریبا 20 کیلو بایت به پایین میشود

        for (int i = 2; i <= rows; i++)
        {
            string branchCode = sheet.Cells[i, 1].Text.Trim();
            string branchName = sheet.Cells[i, 2].Text.Trim();

            if (string.IsNullOrWhiteSpace(branchCode) || string.IsNullOrWhiteSpace(branchName))
                continue;

            Console.WriteLine($"در حال پردازش: {branchName} ({branchCode})");

            try
            {
                using var img = new Bitmap(imagePath);
                using Graphics g = Graphics.FromImage(img);
                g.TextRenderingHint = TextRenderingHint.AntiAlias;

                string text = $"شعبه {branchName} کد {branchCode}";
                float fontSize = maxFontSize;
                Font font = new Font(fontCollection.Families[0], fontSize, FontStyle.Bold);
                SizeF size = g.MeasureString(text, font);

                while (size.Width > img.Width - 2 * rightPadding && fontSize > minFontSize)
                {
                    fontSize--;
                    font = new Font(fontCollection.Families[0], fontSize, FontStyle.Bold);
                    size = g.MeasureString(text, font);
                }

                float x = img.Width - rightPadding - size.Width;
                float y = (img.Height - size.Height) / 2 + marginBottom;
                g.DrawString(text, font, brush, x, y);

                using var result = new MemoryStream();
                Bitmap tempBmp = new Bitmap(img);
                int scale = 100;

                while (true)
                {
                    result.SetLength(0);
                    tempBmp.Save(result, System.Drawing.Imaging.ImageFormat.Png);

                    if (result.Length <= targetSize || scale <= 20)
                        break;

                    scale -= 10;
                    int w = tempBmp.Width * scale / 100;
                    int h = tempBmp.Height * scale / 100;

                    var resized = new Bitmap(tempBmp, w, h);
                    tempBmp.Dispose();
                    tempBmp = resized;
                }

                string base64Image = /*"data:image/png;base64," +*/ Convert.ToBase64String(result.ToArray());

                InsertToDatabase(branchCode, branchName, Convert.ToBase64String(result.ToArray()));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"خطا در پردازش {branchName}: {ex.Message}");
            }
        }

        Console.WriteLine("همه تصاویر با موفقیت در دیتابیس ذخیره شدند");
    }

    static void InsertToDatabase(string branchCode, string branchName, string base64Image)
    {
        const string sql = @"
INSERT INTO Branches_image
(Name, Code, StampFile, IsDeleted, CreatedAt, LastUpdated)
VALUES
(@Name, @Code, @StampFile, 0, @CreatedAt, @LastUpdated);
";

        var connectionString = "Server=192.168.2.157;Database=CHMSDB_PO_14040915;User Id=khalili;Password=sajad136739K@;Encrypt=False;TrustServerCertificate=True;";

        using var connection = new SqlConnection(connectionString);

        var parameters = new
        {
            Name = branchName,
            Code = branchCode,
            StampFile = base64Image,
            CreatedAt = DateTime.Now,
            LastUpdated = DateTime.Now
        };

        connection.Open();
        connection.Execute(sql, parameters);
    }
}
