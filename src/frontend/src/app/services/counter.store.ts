import { computed } from '@angular/core';
import * as zod from 'zod';

const StateSchema = zod.object({
  current: zod.number(),
  by: zod.union([zod.literal(1), zod.literal(3), zod.literal(5)]),
});

import {
  patchState,
  signalStore,
  watchState,
  withComputed,
  withHooks,
  withMethods,
  withState,
} from '@ngrx/signals';
type ValidByOptions = 1 | 3 | 5;
type CounterState = {
  current: number;
  by: ValidByOptions;
};

export type CounterFizzBuzzStatus = 'fizz' | 'buzz' | 'fizzbuzz' | 'none';

const initialState: CounterState = {
  current: 0,
  by: 1,
};

export const CounterStore = signalStore(
  withState(initialState),
  withMethods((store) => {
    return {
      setCountBy: (by: ValidByOptions) => patchState(store, { by: by }),
      increment: () =>
        patchState(store, { current: store.current() + store.by() }),
      decrement: () =>
        patchState(store, { current: store.current() - store.by() }),
      reset: () => patchState(store, initialState),
    };
  }),
  withComputed(({ current }) => {
    return {
      resetShouldBeDisabled: computed(() => current() === 0),
      fizzBuzzStatus: computed<CounterFizzBuzzStatus>(() => {
        if (current() % 3 === 0 && current() % 5 === 0) {
          return 'fizzbuzz';
        }
        if (current() % 3 === 0) {
          return 'fizz';
        }
        if (current() % 5 === 0) {
          return 'buzz';
        }
        return 'none';
      }),
    };
  }),
  withHooks({
    onInit(store) {
      const savedState = localStorage.getItem('counter-state');
      if (savedState !== null) {
        try {
          const suspectObject = JSON.parse(savedState);
          const actualState = StateSchema.parse(suspectObject);
          patchState(store, actualState);
        } catch (e) {
          localStorage.removeItem('counter-state');
        }
      }
      watchState(store, (state) => {
        localStorage.setItem('counter-state', JSON.stringify(state));
      });
    },
  })
);
