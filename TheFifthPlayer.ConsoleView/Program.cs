using TheFifthPlayer.Core;

var player = new Player {
    Position = Position.TOP,
    Nick = "o trevis",
    Discipline = 0.35f,
    CoolHead = 0.35f,
    Mechanics = 0.35f
};

var gen = new Generator(39);
var characters = gen.GenerateCaracters().ToArray();
var players = gen.GeneratePlayers(player).ToArray();

train();

void train()
{
    var opt = options(
        "Qual personagem você gostaria de treinar?",
        table(
            from c in characters
            where c.Position == player.Position
            select new object[] { c.Name, c.Skill1, c.Skill2, c.Ultimate, c.Style }
        )
    );
    var character = characters[opt];

    var result = player.Train(character);
    
    Console.WriteLine($"Você realizou um treinamento com '{character.Name}'.");
    Console.WriteLine(result switch {
        <0.25f => "Foi um treino horrível!",
        <0.5f => "Você já teve dias de práticas que renderam mais...",
        <0.75f => "Foi um bom treino.",
        _     => "Foi um treino excelente!"
    });
    Console.WriteLine(player.GetAbility(character) switch {
        <0.5f => "Você não se sente muito bem com ele ainda...",
        <0.7f => "Você finalmente está pegando o jeito...",
        <0.9f => "Você é confiante com o personagem.",
        _     => "Você sabe que poucos são bons como você!"
    });
}

string[] table(IEnumerable<object[]> values)
{
    var data = values.Select(x => x.Select(y => $" {y} ").ToArray());
    var columns = values.First().Length;
    var columnsSizes = new List<int>();
    for (int i = 0; i < columns; i++)
        columnsSizes.Add(data.Max(x => x[i].Length));

    return data.Select(row => 
        "|" + string.Join("|",
            row.Select(
            (value, i) => value + string.Concat(Enumerable.Repeat(' ', columnsSizes[i] - value.Length))
            )
        ) + "|"
    ).ToArray();

}

int options(string question, string[] opts)
{
    int left, top;
    var curr = 0;
    var bigger = opts.Max(s => s.Length);
    bigger = int.Max(bigger + 3, 20);
    (left, top) = (Console.CursorLeft, Console.CursorTop);
    while (true)
    {
        (Console.CursorLeft, Console.CursorTop) = (left, top);
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine(question);
        for (int i = 0; i < opts.Length; i++)
        {
            var message = string.Empty;
            if (i == curr)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                message += " > ";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                message += "   ";
            }
            message += opts[i] + string.Concat(Enumerable.Repeat(' ', bigger - opts[i].Length));
            Console.WriteLine(message);
        }

        var key = Console.ReadKey(true);
        if (key.Key == ConsoleKey.W)
            curr = int.Clamp(curr - 1, 0, opts.Length - 1);
        if (key.Key == ConsoleKey.S)
            curr = int.Clamp(curr + 1, 0, opts.Length - 1);
        if (key.Key == ConsoleKey.Enter)
            break;
    }
    return curr;
}