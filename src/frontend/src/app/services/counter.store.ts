import { patchState, signalStore, withMethods, withState } from "@ngrx/signals"


type CounterState = {
    current: number
    
}

const initialState: CounterState = {
    current: 0,
    
}

export const CounterStore = signalStore(
    withState(initialState),
    withMethods((store) => {
        return {
            increment: () => patchState(store, { current: store.current() + 1}),
            decrement: () => patchState(store, { current: store.current() - 1})
        }
    })
)