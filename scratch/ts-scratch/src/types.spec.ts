import { expect, test, describe } from 'vitest';

describe("basic stuff", () => {

    test("Can add two numbers", () => {
        expect(1 + 1).toBe(2)
    });

    test("implicit typing", () => {
        let a = 12 ;
        let b = 'Food';
        let c: string[];

        a = 12;
        c = ['Dog', 'Cat']
        expect(a).toBe(12);
        
        b = "Tacos";
           
        expect(b).toBe("Tacos");
    });

    test('const is sorta cost', () => {
        const name = 'Joe';
        const age = 99;

       const pets = ['Bailey', 'Spike'];
       
        pets[1] = "Spikey";

        // Anonymous Object and an anonymous type all in one!
        const movie = { title: 'Constantine', cast: ['Keanu Reeves']};

        expect(movie.title).toBe("Constantine");
        expect(movie.cast.length).toBe(1);
        movie.cast[0] = "Woah!";

        type SoftwareItem = { id: string, title: string};
        const softwareItem = { id: "1", title: "Jetbrains Rider"};

        doStuffWithSoftware(softwareItem);
        // Structural Typing - 
        doStuffWithSoftware({id: '42', title: 'The Phantom Menace'});
        function doStuffWithSoftware(item:SoftwareItem) {
            console.log(item.id + " is " + item.title)
        }

       

    });

    test('unions', () => {
        
        let thing: number | string;
        thing = 420
        // Discriminated Unions.
    });
})