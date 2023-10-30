using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Sample.VerifyQuestPdf;

public class PdfGenerator
{
    public static IDocument GenerateDocument() =>
        Document.Create(container =>
        {
            container.Page(AddPage);
            container.Page(AddPage);
        });

    static void AddPage(PageDescriptor page)
    {
        page.Size(PageSizes.A5);
        page.Margin(1, Unit.Centimetre);
        page.PageColor(Colors.Grey.Lighten3);
        page.DefaultTextStyle(_ => _.FontSize(20));

        page.Header()
            .Text("Hello PDF!")
            .SemiBold().FontSize(36);

        page.Content()
            .Column(x =>
            {
                x.Item()
                    .Text(Placeholders.LoremIpsum());
            });

        page.Footer()
            .AlignCenter()
            .Text(x =>
            {
                x.Span("Page ");
                x.CurrentPageNumber();
            });
    }
}