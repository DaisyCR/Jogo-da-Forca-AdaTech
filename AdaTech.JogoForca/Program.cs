namespace AdaTech.JogoForca;

public class Program
{
    public static void Main()
    {
        var palavras = new Dictionary<string, string>
        {
            {"laranja", "fruta"},
            {"onibus", "veiculo"},
            {"brasil", "país"},
            {"primo", "familía"},
            {"sabonete", "banheiro"}
        };
        
        foreach (var (palavra, tema) in palavras)
        {
            Console.WriteLine("\n--------Novo Jogo--------");
            //Six lives as in: head, body, 2 arms and 2 legs
            var jogo = new JogoForca(palavra, tema, 6);
            jogo.Play();
        }
    }
}