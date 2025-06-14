interface Stackable<T> {
  push(item: T): void;
  pop(): T | undefined;
  peek(): T | undefined;
  isEmpty(): boolean;
}

class Stack<T> implements Stackable<T> {
  private items: T[] = [];

  push(item: T): void {
    this.items.push(item);
  }

  pop(): T | undefined {
    return this.items.pop();
  }

  peek(): T | undefined {
    return this.items.at(-1);
  }

  isEmpty(): boolean {
    return this.items.length === 0;
  }

  size(): number {
    return this.items.length;
  }
}

// Example usage with numbers
const numberStack = new Stack<number>();
numberStack.push(10);
numberStack.push(20);
numberStack.push(30);
console.log(numberStack.peek()); // Output: 30
console.log(numberStack.pop()); // Output: 30
console.log(numberStack.size()); // Output: 2
console.log(numberStack.isEmpty()); // Output: false
// numberStack.push("string"); // Error: Argument of type 'string' is not assignable to parameter of type 'number'

// Example usage with strings
const stringStack = new Stack<string>();
stringStack.push("Hello");
stringStack.push("TypeScript");
console.log(stringStack.peek()); // Output: TypeScript
console.log(stringStack.pop()); // Output: TypeScript
console.log(stringStack.size()); // Output: 1
console.log(stringStack.isEmpty()); // Output: false

// Example usage with custom objects
interface User {
  name: string;
  id: number;
}

const userStack = new Stack<User>();
userStack.push({ name: "Leila", id: 1 });
userStack.push({ name: "Jose", id: 2 });
userStack.push({ name: "Artur", id: 2 });

console.log('Peak:', userStack.peek());
while (!userStack.isEmpty()) {
  const user = userStack.pop();
  console.log(user);
}