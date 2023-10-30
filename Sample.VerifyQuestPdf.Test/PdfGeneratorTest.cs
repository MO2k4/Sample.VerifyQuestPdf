using System.Runtime.CompilerServices;
using QuestPDF;
using QuestPDF.Infrastructure;

namespace Sample.VerifyQuestPdf.Test;

[UsesVerify]
public class PdfGeneratorTest
{
    [ModuleInitializer]
    internal static void Init() => VerifyTests.VerifyQuestPdf.Initialize();

    [Fact]
    public Task ShouldWork()
    {
        Settings.License = LicenseType.Community;

        var model = InvoiceDocumentDataSource.GetInvoiceDetails();
        return Verify(new InvoiceDocument(model));
    }
}