using CodeTestGSI;

var solution = new Solution();


// Test case  soal 1
var result1Q1 = solution.Question1("Titanic");
var result2Q1 = solution.Question1("Avenger Endgame");
Console.WriteLine("=============================");
// Test case  soal 2
var result1Q2 = solution.Question2(result1Q1);
var result2Q2 = solution.Question2(result2Q1);
Console.WriteLine("=============================");

// Test case  soal 3
var result1Q3 = solution.Question3(result1Q2);
var result2Q3 = solution.Question3(result2Q2);
Console.WriteLine("=============================");

// Test case  soal 4
var result1Q4 = solution.Question4(result1Q3);
var result2Q4 = solution.Question4(result2Q3);
Console.WriteLine("=============================");

// Test case  soal 5
var result1Q5 = solution.Question5(result1Q4);
var result2Q5 = solution.Question5(result2Q4);
