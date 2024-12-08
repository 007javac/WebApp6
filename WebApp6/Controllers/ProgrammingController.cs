using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class ProgrammingController : Controller
{
    // Список языков программирования
    private static readonly List<ProgrammingLanguage> _languages = new List<ProgrammingLanguage>
    {
        new ProgrammingLanguage
        {
            Name = "CSharp",
            Description = "Объектно-ориентированный язык программирования от Microsoft",
            CodeExample = "Console.WriteLine(\"Hello, World!\");"
        },
        new ProgrammingLanguage
        {
            Name = "Python",
            Description = "Высокоуровневый язык программирования с простым синтаксисом",
            CodeExample = "print(\"Hello, World!\")"
        },
        new ProgrammingLanguage
        {
            Name = "JavaScript",
            Description = "Язык программирования для веб-разработки",
            CodeExample = "console.log(\"Hello, World!\");"
        }
    };

    // Отображение списка языков
    public IActionResult Index()
    {
        return View(_languages);
    }

    // Информация о языке программирования
    public IActionResult Info(string language, string color = "black")
    {
        var lang = _languages.FirstOrDefault(l => l.Name.ToLower() == language.ToLower());
        if (lang == null)
            return NotFound();

        ViewBag.Color = color;
        return View(lang);
    }

    // Пример кода для языка программирования
    public IActionResult Example(string language)
    {
        language = HttpUtility.UrlDecode(language);
        var lang = _languages.FirstOrDefault(l => l.Name.ToLower() == language.ToLower());
        if (lang == null)
            return NotFound();

        return View(lang);
    }
}
