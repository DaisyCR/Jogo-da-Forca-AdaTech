namespace AdaTech.JogoForca;

internal class JogoForca
{
    private int _lives;
    private readonly string _keyword;
    private readonly string _theme;
    private readonly HashSet<string> _previousGuesses;
    private bool _victory;

    public JogoForca(string keyword, string theme, int lives)
    {
        this._lives = lives;
        this._keyword = keyword.ToUpper();
        this._theme = theme.ToUpper();
        this._victory = false;
        this._previousGuesses = new HashSet<string>();
    }
    
    public void Play()
    {
        Console.WriteLine($"Vidas: {_lives}\nTema: {_theme}");
        DisplayCorrectGuesses();
        
        while (_lives > 0 && _victory == false)
        {
            var guess = GetUserInput();
            if (!IsLetterInKeyword(guess))
            {
                Console.WriteLine("A letra digitada não existe na palavra-chave!");
                _lives--;
            }
            Console.WriteLine($"\nVidas: {_lives}\nTema: {_theme}");
            _previousGuesses.Add(guess);
            DisplayWrongGuesses();
            DisplayCorrectGuesses();
        }
        
        Console.WriteLine(_victory ? "Você venceu!": $"FIM DE JOGO! A palavra-chave era {_keyword}.");
    }
    
    private void DisplayWrongGuesses()
    {
        Console.Write("Escolhas Erradas: ");
        foreach (var letter in _previousGuesses.Where(letter => !_keyword.Contains(letter)))
        {
            Console.Write($"{letter} ");
        }
        Console.WriteLine();
    }

    private void DisplayCorrectGuesses()
    {
        var display = "";
        foreach (var letter in _keyword)
        {
            if (letter.ToString() == " ")
            {
                display += letter;
                continue;
            }
            display += _previousGuesses.Contains(letter.ToString()) ? letter : "_";
        }

        if (display == _keyword)
        {
            _victory = true;
        }
        Console.WriteLine(display);
    }
    
    private bool IsLetterInKeyword(string guess)
    {
        return _keyword.Any(letter => guess == letter.ToString());
    }

    private static string GetUserInput()
    {
        while (true)
        {
            Console.Write("Digite uma letra: ");
            if (char.TryParse(Console.ReadLine(), out var input)) return input.ToString().ToUpper();
            Console.WriteLine("ERRO! Insira apenas uma letra!");
        }
    }
}