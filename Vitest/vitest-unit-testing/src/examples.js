// 01-Wprowadzenie
export function longestString(stringOne, stringTwo) {
  // Zwraca dłuższy ciąg znaków.
  // Jeśli są równe, zwraca stringOne.
  
  // Poprawka: Aby obsłużyć przypadki brzegowe z pustymi przestrzeniami
  // w późniejszych testach, musimy użyć trim().
  
  const trimmedStringOne = stringOne.trim();
  const trimmedStringTwo = stringTwo.trim();

  if (trimmedStringTwo.length > trimmedStringOne.length) {
    return stringTwo;
  } else {
    return stringOne;
  }
}


// 02-Różne-Matchery
export function isPrime(num) {
  // 1. Sprawdzenie typu danych (Wyrzucenie błędu)
  if (typeof num !== 'number') {
    throw new Error('Input must be a number'); 
  }

  // 2. Sprawdzenie, czy jest liczbą całkowitą (aby obsłużyć 2.5)
  if (!Number.isInteger(num)) {
    return false; // Niecałkowite liczby nie są pierwsze
  }

  // 3. Sprawdzenie małych liczb (0, 1 i ujemne)
  if (num <= 1) {
    return false; // Zero i liczby ujemne nie mogą być pierwsze
  }
  
  // 4. Główna logika (iterujemy tylko do pierwiastka kwadratowego)
  for (let i = 2; i <= Math.sqrt(num); i++) {
    if (num % i === 0) {
      return false; // Liczba nie jest pierwsza
    }
  }

  return true; // Liczba jest pierwsza
}
