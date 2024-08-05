import { patchState, signalStore, withComputed, withMethods } from '@ngrx/signals';
import { addEntity, updateEntity, withEntities } from '@ngrx/signals/entities';
import { TodoListItem, TodoListSummary } from '../todo-list/models';
import { computed } from '@angular/core';

export const TodosStore = signalStore(
  { providedIn: 'root' },
  withEntities<TodoListItem>(),
  withComputed(({entities}) => {
    
    return {
        
        getSummary: computed(() => {
            return {
                totalItems: entities().length,
                incompleteItems: entities().filter(t => t.completed === false).length,
                completeItems: entities().filter(t => t.completed === true).length
            }  as TodoListSummary
        })
    }
  }),
  withMethods((state) => {
    return {
      markTodoComplete(item: TodoListItem) {
        patchState(state, updateEntity({id: item.id, changes: {
         
          completed: true}}))
      },

      addTodoItem(description: string) {
        const newItem: TodoListItem = {
          id: crypto.randomUUID(),
          description,
          completed: false,
        };
        patchState(state, addEntity(newItem));
      },
    };
  })
);

// Entities: Objects that are in lists of things that are compared using an ID.
