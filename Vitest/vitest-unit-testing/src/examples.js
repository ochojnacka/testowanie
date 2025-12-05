// src/examples.js
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
