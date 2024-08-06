import {
  patchState,
  signalStoreFeature,
  withMethods,
  withState,
} from '@ngrx/signals';

export type ApiDataState = {
  isLoading: boolean;
};

export function withApiLoadingState() {
  return signalStoreFeature(
    withState<ApiDataState>({ isLoading: false }),
    withMethods((state) => {
      return {
        setLoading: () => patchState(state, { isLoading: true }),
        doneLoading: () => patchState(state, { isLoading: false }),
      };
    })
  );
}
