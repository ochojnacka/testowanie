// 01-Wprowadzenie
import { describe, it, expect } from 'vitest';
import { longestString } from '../src/examples';

// Opisujemy funkcję, którą testujemy
describe('examples.longestString', () => { 
  // Wewnątrz umieszczamy przypadki testowe

    it('zwraca najdłuższy ciąg znaków', () => {
        // 1. Wywołanie funkcji
        const longest = longestString('Pikachu', 'Snorlax'); 

        // 2. Asercja: Oczekujemy, że dłuższym ciągiem jest 'Pikachu'
        expect(longest).toBe('Pikachu'); 
    });

    it('zwraca pierwszy ciąg, gdy oba są równej długości', () => {
        // Ditto i Ekans mają po 5 znaków
        expect(longestString('Ditto', 'Ekans')).toBe('Ditto');

        // Uwaga: Możemy wywołać funkcję bezpośrednio w expect, jeśli zwraca prostą wartość.
    });

    it('obsługuje puste ciągi znaków', () => {
        // Pusty vs Mario
        expect(longestString('', 'Mario')).toBe('Mario');

        // Luigi vs Pusty
        expect(longestString('Luigi', '')).toBe('Luigi');

        // Oba puste (zwraca pierwszy)
        expect(longestString('', '')).toBe('');
    });

    it('ignoruje wiodące i końcowe białe znaki', () => {
        // Dłuższy ciąg ze spacjami (Ash), ale po usunięciu spacji krótszy niż Misty
        expect(longestString('   Ash   ', 'Misty')).toBe('Misty');
    });
});


// 02-Różne-Matchery
import { isPrime } from '../src/examples';

describe('examples.isPrime', () => {
    it('zwraca true lub truthy dla małych liczb pierwszych', () => {
        expect(isPrime(2)).toBe(true);
        expect(isPrime(3)).toBe(true);
        expect(isPrime(5)).toBeTruthy();
    });

    it('zwraca false lub falsy dla liczb niepierwszych i nieprawidłowych (0,1)', () => {
        expect(isPrime(0)).toBe(false);
        expect(isPrime(1)).toBe(false);
        expect(isPrime(4)).toBeFalsy();
    });

    it('dopasowuje wyniki w tablicy używając toEqual', () => {
        const numbers = [2, 3, 4, 5];

        // Mapujemy tablicę, aby uzyskać tablicę wyników true/false
        const results = numbers.map(isPrime);

        // Oczekiwana tablica wyników:
        const expectedArray = [true, true, false, true];

        // Użycie toEqual, ponieważ sprawdzamy zawartość tablicy
        expect(results).toEqual(expectedArray);

        // WAŻNE: Gdybyśmy użyli expect(results).toBe(expectedArray),
        // test ZAWSZE by się nie powiódł, ponieważ są to różne referencje w pamięci.
    });

    it('wykrywa liczby pierwsze w przefiltrowanej liście', () => {
        const nums = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

        // Filtrujemy tablicę, aby uzyskać tylko liczby pierwsze
        const primes = nums.filter(isPrime);

        // 1. Sprawdzamy czy 2, 3, 5 i 7 są w tablicy
        expect(primes).toContain(2);
        expect(primes).toContain(3);
        expect(primes).toContain(5);
        expect(primes).toContain(7);
        
        // 2. Sprawdzamy czy 1, 4, 6, 8, 9 i 10 nie są w tablicy
        // Używamy modyfikatora 'not', który odwraca działanie matchera
        expect(primes).not.toContain(1);
        expect(primes).not.toContain(4);
        expect(primes).not.toContain(6);
        expect(primes).not.toContain(8);
        expect(primes).not.toContain(9);
        expect(primes).not.toContain(10);
    });

    it('rzuca błąd, gdy przekazano argument, który nie jest liczbą', () => {
        // 1. Definiujemy 'złe wywołanie' jako funkcję (opakowujemy wywołaenie w funkcję)
        const badCall = () => {
            isPrime('Pikachu');
        };

        // 2. Asercja: Przekazujemy funkcję 'badCall' (nie wywołaną) i oczekujemy błędu
        expect(badCall).toThrow(); // Sprawdza, czy rzucany jest jakikolwiek błąd

        // 3. Sprawdzenie konkretnej wiadomości błędu (opcjonalne, ale zalecane)
        const badCallWithSpecificError = () => {
            isPrime(null);
        };

        // Możemy podać oczekiwany ciąg znaków błędu jako argument
        expect(badCallWithSpecificError).toThrow('Input must be a number');
    });

    it('zwraca poprawny typ dla wyniku', () => {
        // Dla poprawnego inputu (7), oczekujemy wartości logicznej (true/false)

        // WAŻNE: Funkcję możemy wywołać bezpośrednio, ponieważ zwraca wartość, a nie rzuca błędu.
        expect(isPrime(7)).toBeTypeOf('boolean') // alt: expect(typeof isPrime(7)).toBe('boolean');
    });
});
