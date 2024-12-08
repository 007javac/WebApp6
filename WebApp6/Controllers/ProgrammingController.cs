using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class ProgrammingController : Controller
{
    // ������ ������ ����������������
    private static readonly List<ProgrammingLanguage> _languages = new List<ProgrammingLanguage>
    {
        new ProgrammingLanguage
        {
            Name = "CSharp",
            Description = "��������-��������������� ���� ���������������� �� Microsoft",
            CodeExample = "Console.WriteLine(\"Hello, World!\");"
        },
        new ProgrammingLanguage
        {
            Name = "Python",
            Description = "��������������� ���� ���������������� � ������� �����������",
            CodeExample = "print(\"Hello, World!\")"
        },
        new ProgrammingLanguage
        {
            Name = "JavaScript",
            Description = "���� ���������������� ��� ���-����������",
            CodeExample = "console.log(\"Hello, World!\");"
        }
    };

    // ����������� ������ ������
    public IActionResult Index()
    {
        return View(_languages);
    }

    // ���������� � ����� ����������������
    public IActionResult Info(string language, string color = "black")
    {
        var lang = _languages.FirstOrDefault(l => l.Name.ToLower() == language.ToLower());
        if (lang == null)
            return NotFound();

        ViewBag.Color = color;
        return View(lang);
    }

    // ������ ���� ��� ����� ����������������
    public IActionResult Example(string language)
    {
        language = HttpUtility.UrlDecode(language);
        var lang = _languages.FirstOrDefault(l => l.Name.ToLower() == language.ToLower());
        if (lang == null)
            return NotFound();

        return View(lang);
    }
}
