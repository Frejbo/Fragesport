int score = 0;

Dictionary<string, Action> quizzes = new();

quizzes.Add("apple", apple);
quizzes.Add("flyg", flyg);

bool gameActive = true;
while (gameActive) {
    string currentTheme = "";
    while (!quizzes.ContainsKey(currentTheme)) {
        Console.WriteLine("Vilket tema vill du ha på frågorna? Apple/Flyg");
        currentTheme = Console.ReadLine().ToLower();
        Console.ForegroundColor = ConsoleColor.Yellow;
        if (!quizzes.ContainsKey(currentTheme)) {Console.WriteLine("Du måste skriva något av alternativen.");}
        Console.ResetColor();
    }

    quizzes[currentTheme]();
    Console.WriteLine($"Du fick {score} poäng på {currentTheme}! Vill du köra ett annat quiz?");
    if (Console.ReadLine().ToLower() != "ja") {
        gameActive = false;
        System.Console.WriteLine("Hejdå tråkmåns :(");
        Console.ReadLine();
    }
}

void apple() {
    Console.WriteLine("-- Apple Frågesport --");
    System.Console.WriteLine("Vilken var den första iPhonen med MagSafe?\nA) iPhone 7\nB) iPhone X\nC) iPhone 11 Pro\nD) iPhone 12\nE) iPhone 13");
    if (request_answer("D", true)) {score++;}
    
    System.Console.WriteLine("Vad hette den första telefonen?\nA) iPhone 1G\nB) iPhone 2G\nC) iPhone 3G\nD) iPhone 3GS");
    if (request_answer("B", true)) {score++;}

    System.Console.WriteLine("Vilket chip använder iPhone 14 Pro? Svara 3 tecken.");
    if (request_answer("A16")) {score++;}

    System.Console.WriteLine("Vilket år släpptes iPhone X?");
    if (request_answer("2017")) {score++;}
}

void flyg() {
    Console.WriteLine("-- Flyg Frågesport --");
    
    Console.WriteLine("Vad står APU för?");
    if (request_answer("Auxiliary Power Unit")) {score++;}

    Console.WriteLine("När planet lyfter så finns en point of no return, endast ytterst allvarliga fel kan förhindra detta då planet inte längre hinner stanna säkert på banan. Vid denna punkt ropar piloterna ut en term på 2 tecken. Vad är denna term?");
    if (request_answer("V1")) {score++;}

    Console.WriteLine("Vad är den vanligaste typen av approaches för kommersiella flygplan?\nA) RNAV\nB) VOR\nC) ILS\nD) VFR");
    if (request_answer("C", true)) {score++;}

    Console.WriteLine("Vad är Arlandas ICAO kod?");
    if (request_answer("ESSA")) {score++;}

    Console.WriteLine("Vad står 'CI' för?");
    if (request_answer("Cost Index")) {score++;}

    Console.WriteLine("Vad är standard QNH? Svara i HPA och endast siffror.");
    if (request_answer("1013")) {score++;}
}
// orkar inte komma på fler quizz :P


bool request_answer(string answer, bool abc_question = false, bool require_correct = false) {
    string input = "";
    answer = answer.ToLower();
    if (require_correct) { // används inte atm
        while (input != answer) {
            Console.ForegroundColor = ConsoleColor.Yellow;

            input = Console.ReadLine().ToLower();
            if (input != answer) {Console.WriteLine("Fel, försök igen!");}
        }
        Console.ForegroundColor = ConsoleColor.Green;
        System.Console.WriteLine("Rätt!");
        Console.ResetColor();
}
    else if (abc_question) {
        while (input.Length != 1) {
            input = Console.ReadLine().ToLower();
            if (input == answer.ToLower()) {
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine("Rätt!");
                Console.ResetColor();
            }
            else if (input.Length != 1) {
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine("Svara med 1 bokstav. Försök igen.");
                Console.ResetColor();
            }
            else {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"Fel! Rätt svar var {answer}.");
                Console.ResetColor();
            }
        }
    }
    else {
        input = Console.ReadLine().ToLower();
        if (input == answer) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Rätt!", Console.ForegroundColor);
            Console.ResetColor();
        }
        else {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Fel! Rätt svar var {answer}.");
            Console.ResetColor();
        }
    }
    return ((input == answer.ToLower()));
}