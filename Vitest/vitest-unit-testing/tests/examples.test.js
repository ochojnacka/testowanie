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
