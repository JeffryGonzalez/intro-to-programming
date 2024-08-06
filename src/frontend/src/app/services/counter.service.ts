import { computed, Injectable, signal } from "@angular/core";

@Injectable({providedIn: 'root'})
export class CounterService {

    #current = signal(0);

    getCurrent() {
        return this.#current.asReadonly();
    }

    increment() {
        this.#current.update(c => c + 1);
    }

    decrement() {
        this.#current.update(c => c - 1)
    }


}