// 01-Wprowadzenie
import { describe, it, expect } from 'vitest';
import { longestString } from '../src/examples';

// Opisujemy funkcję, którą testujemy
describe('examples.longestString', () => { 
  // Wewnątrz umieszczamy przypadki testowe

    it('zwraca najdłuższy ciąg znaków', () => {
        // 1. Wywołanie funkcji
        const longest = longestString('Pikachu', 'Ditto'); 

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

// 03-Lepsze-testy-i-Boundary-Testing
describe('examples.isPrime', () => {
    it('traktuje 0 i 1 jako niepierwsze oraz 2 jako pierwszą', () => {
        expect(isPrime(0)).toBe(false);
        expect(isPrime(1)).toBe(false);
        expect(isPrime(2)).toBe(true);
    });

    it('zwraca false lda liczb parzystych większych niż 2', () => {
        expect(isPrime(4)).toBe(false);
        expect(isPrime(100)).toBe(false);
        expect(isPrime(1000)).toBe(false);
    });

    it('zwraca false dla kwadratów liczb całkowitych', () => {
        expect(isPrime(9)).toBe(false);
        expect(isPrime(16)).toBe(false);
        expect(isPrime(25)).toBe(false);
    });

    it('zwraca false dla liczb niecałkowitych', () => {
        expect(isPrime(2.5)).toBe(false);
        expect(isPrime(3.14)).toBe(false);
        expect(isPrime(7.1)).toBe(false);
    });

    it('rzuca błąd dla danych niebędących liczbami', () => {
        const badCall = () => {
            isPrime('Charmander');
        };

        expect(badCall).toThrow();
    });
});

import { shippingCost } from '../src/examples';

describe('examples.shippingCost', () => {
    // Testowanie kosztów (Asercje silne)
    it('nalicza poprawne ceny dla wag wewnętrznych (interior weights)', () => {
        // Waga 1.5 kg (powinna wpaść w zakres > 1 i <= 5)
        expect(shippingCost(1.5)).toBe(5.99);
        // Waga 10 kg (powinna wpaść w zakres > 5 i <= 20)
        expect(shippingCost(10)).toBe(8.99);
        // Waga 30 kg (powinna wpaść w zakres > 20)
        expect(shippingCost(30)).toBe(14.99);
    });

    // Testowanie granic (Boundary Testing)
    it('nalicza poprawne ceny dla wag granicznych (boundary weights)', () => {
        // Waga dokładnie na granicy pierwszego progu
        expect(shippingCost(1)).toBe(3.99);
        // Waga dokładnie na granicy drugiego progu
        expect(shippingCost(5)).toBe(5.99);
        // Waga dokładnie na granicy trzeciego progu
        expect(shippingCost(20)).toBe(8.99);
        // Waga minimalnie powyżej trzeciego progu (Tier 4)
        expect(shippingCost(21)).toBe(14.99);
    });

    // Testowanie logiki biznasowej i błędów
    // Testowanie kuponów
    it('poprawnie stosuje kupon FREE_SHIPPING', () => {
        // Sprawdzamy z wagą 2 (normalnie - 5.99), oczekulemy 0 z kuponem
        expect(shippingCost(2, 'FREE_SHIPPING')).toBe(0);
    });

    it('ignoruje kupony, które nie pasują do wzorca', () => {
        // Małe litery nie pasują (oczekujemy normalnej ceny dla wagi 1)
        expect(shippingCost(1, 'free_shipping')).toBe(3.99);

        // Nieznany kupon (oczekujemy normalnej ceny dla wagi 1)
        expect(shippingCost(1, 'SAVE10')).toBe(3.99);

        // Brak kuponu (waga 1), co jest wartością domyślną
        expect(shippingCost(1)).toBe(3.99);
    });

    // Testowanie błędów: Wagi nieprawidłowe
    it('rzuca błąd dla nieprawidłowych wag (<= 0)', () => {
        // Waga 0 (Invalid)
        const zeroWeightCall = () => {
            shippingCost(0);
        };
        // Regex: Oczekujemy słowa 'weight' i 'zero' (case insensitive)
        expect(zeroWeightCall).toThrow(/weight.*zero/i);

        // Waga ujemna (Invalid)
        const negativeWeightCall = () => {
            shippingCost(-5);
        };
        expect(negativeWeightCall).toThrow(/weight.*zero/i);
    });

    // Testowanie błędów: Nieprawidłowe typy wejściowe
    it('rzuca błąd, gdy waga jest nieprawidłowym typem', () => {
        // String zamiast Number dla wagi
        const stringWeightCall = () => {
            shippingCost('2', 'FREE_SHIPPING');
        };
        // Funkcja rzuca błąd 'Weight must be a number...'
        expect(stringWeightCall).toThrow(/number/i);
    });

    it('rzuca bład, gdy kupon nie jest ciągiem znaków', () => {
        // Kupon jako Number zamiast String
        const numberCouponCall = () => {
            shippingCost(1, 12345);
        };
        // Oczekujemy błędu ze słowem 'coupon'
        expect(numberCouponCall).toThrow(/coupon/i);

        // Kupon jako Null zamiast String
        const nullCouponCall = () => {
            shippingCost(1, null);
        };
        expect(nullCouponCall).toThrow(/coupon/i);
    });
});