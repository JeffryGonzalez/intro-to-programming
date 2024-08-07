import {
  patchState,
  signalStore,
  withComputed,
  withHooks,
  withMethods,
} from '@ngrx/signals';
import {
  addEntities,
  addEntity,
  updateEntity,
  withEntities,
} from '@ngrx/signals/entities';
import { TodoListItem, TodoListSummary } from '../todo-list/models';
import { computed, inject } from '@angular/core';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { concatMap, pipe, switchMap, tap } from 'rxjs';
import { TodosDataService } from './todos-data.service';
import { tapResponse } from '@ngrx/operators';
import { withApiLoadingState } from './api.store-feature';

export const TodosStore = signalStore(
  { providedIn: 'root' },
  withApiLoadingState(),
  withEntities<TodoListItem>(),
  withComputed(({ entities }) => {
    return {
      getSummary: computed(() => {
        return {
          totalItems: entities().length,
          incompleteItems: entities().filter((t) => t.completed === false)
            .length,
          completeItems: entities().filter((t) => t.completed === true).length,
        } as TodoListSummary;
      }),
    };
  }),
  withMethods((state) => {
    const dataService = inject(TodosDataService);
    return {
      loadTodos: rxMethod<void>(
        pipe(
          tap(() => state.setLoading()), // do
          switchMap(() => dataService.loadTodos()),
          tapResponse({
            next: (items) => {
              patchState(state, addEntities(items));
              state.doneLoading();
            },
            error: (err) => console.error('Bummer', err),
          })
        )
      ),
      markTodoComplete(item: TodoListItem) {
        patchState(
          state,
          updateEntity({
            id: item.id,
            changes: {
              completed: true,
            },
          })
        );
      },

      addTodoItem: rxMethod<string>(
        pipe(
          concatMap((description) => dataService.addTodo({ description })),
          tapResponse({
            next: (item) => patchState(state, addEntity(item)),
            error: (err) => console.error(err),
          })
        )
      ),
    };
  }),
  withHooks({
    onInit(store) {
      //store._loadTodos();
    },
  })
);

// Entities: Objects that are in lists of things that are compared using an ID.
