# Kata String Calculator

## Zasady
Kierowca (osoba przy klawiaturze) pisze test (który nie przechodzi).
Pilot sprawdza czytelność, sensowność, korzystanie z dobrych praktyk. 
Osoby zamieniają się rolami.
Kierowca pisze implementacje testów nieprzechodzących i następne testy
…. I tak dalej ?


## Wymagania:
1. Utwórz klasę StringCalculator z jedną metodą int Add(string numbers)
- Metoda może przyjmować 0, 1 lub 2 numery i zwraca ich sumę (dla pustego łańcucha zwróci 0) np.: “” lub “1” lub “1,2”
- Rozpocznij z najprostszym przypadkiem – pusty łańcuch. Następnie zaimplementuj dla jednego I dwóch numerów
- Pamiętaj aby używać najprostszych rozwiązań w taki sposób by pisać testy o których wcześniej nie myślałeś
- Pamiętaj o refaktoringu po każdym przechodzącym teście

2. Metoda Add może przyjmować nieokreśloną ilość numerów np.”1,2,3,4,5,6”

3. Metoda Add może przyjmować znaki końca linii pomiędzy numerami (zamiast przecinków).
- Poniższy łańcuch jest poprawny:  “1\n2,3”  (wynik - 6)
- Poniższy łańcuch nie jest poprawny:  “1,\n” 

4. Wsparcie dla różnego rodzaju znaków podziału
- Żeby zmienić znak podziału, początek linii musi się zaczynać : “//[delimiter]\n[numbers…]” 
np.:  “//;\n1;2” powinno zwrócić 3 i ustawić znak podziału na ‘;’ .
- Pierwsza linia jest opcjonalna 

5. Jeżeli numer jest liczą ujemną to powinien być rzucony wyjątek o treści “Liczny ujemny niedozwolone”. 
Opis powinien zawierać liczbę która spowodowała błąd. Jeżeli było więcej liczb ujemnych to wszystkie powinny się znaleźć w opisie

6. Liczby większe niż  1000 powinny być ignorowane np.: 2 + 1001  = 2

7.	Znaki podziału mogą być dowolnej długości ale zgodne z formatem :  “//[delimiter]\n” np.: np.: “//[***]\n1***2***3” powinien zwrócić 6

8.	Dodaj wiele znaków podziału zgodnie z formatem :  “//[delim1][delim2]\n” 
np.: “//[*][%]\n1*2%3” powinien zwrócić 6.

9.	Upewnij się że można podać wiele znaków podziału każdy dłuższy niż jeden znak


