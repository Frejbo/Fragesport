int score = 0;

Dictionary<string, Action> quizzes = new();

quizzes.Add("geografi", geografi);
quizzes.Add("flyg", flyg);

bool gameActive = true;
while (gameActive) {
    string currentTheme = "";
    while (!quizzes.ContainsKey(currentTheme)) {
        Console.WriteLine("Vilket tema vill du ha på frågorna? Geografi/Flyg");
        currentTheme = Console.ReadLine().ToLower();
        if (!quizzes.ContainsKey(currentTheme)) {Console.WriteLine("Du måste skriva något av alternativen.");}
    }

    quizzes[currentTheme]();
    Console.WriteLine($"Du fick {score} poäng på {currentTheme}! Vill du köra igen?");
    if (Console.ReadLine().ToLower() != "ja") {
        gameActive = false;
    }
}

void geografi() {
    Console.WriteLine("-- Geografi Frågesport --");
    Console.WriteLine("Vad heter världens högsta torn?");
}

void flyg() {
    Console.WriteLine("-- Flyg Frågesport --");

    // (string text, bool correct) result = request_answer("APU");
    // Console.WriteLine(result.text);
    
    Console.WriteLine("Vad står APU för?");
    if (request_answer("Auxiliary Power Unit")) {score++;}

    Console.WriteLine("När planet lyfter så finns en point of no return, endast ytterst allvarliga fel kan förhindra detta då planet inte längre hinner stanna säkert på banan. Vid denna punkt ropar piloterna ut en term på 2 tecken. Vad är denna term?");
    if (request_answer("V1")) {score++;}
}


bool request_answer(string answer, bool require_correct = false) {
    string input = "";
    answer = answer.ToLower();
    if (require_correct) {
        while (input != answer) {
            input = Console.ReadLine().ToLower();
            if (input != answer) {Console.WriteLine("Fel, försök igen!");}
        }
        Console.WriteLine("Rätt!");
    }
    else {
        input = Console.ReadLine().ToLower();
        if (input == answer) {
            Console.WriteLine("Rätt!");
            score++;
        }
        else {
            Console.WriteLine($"Fel! Rätt svar var {answer}.");
        }
    }
    return ((input == answer.ToLower()));
}


Console.WriteLine("PROGRAMMET SLUT");
Console.ReadLine();