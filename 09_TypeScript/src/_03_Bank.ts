class BankAccount {
  protected balance: number;
  public readonly id: string;
  private _customerName: string;

  constructor(id: string, customerName: string, initialBalance: number = 0) {
    this.id = id;
    this._customerName = customerName;
    this.balance = initialBalance;
  }

  get customerName(): string {
    return this._customerName;
  }

  set customerName(name: string) {
    if (name.trim().length > 0) {
      this._customerName = name;
      console.log(`Customer name updated to: ${name}`);
    } else {
      throw new Error("Customer name cannot be empty.");
    }
  }

  deposit(amount: number): void {
    if (amount <= 0) {
      throw new Error("Deposit amount must be positive.");
    }
    this.balance += amount;
    console.log(`Deposited $${amount}. New balance: $${this.balance}`);
  }

  withdraw(amount: number): void {
    if (amount <= 0) {
      throw new Error("Withdrawal amount must be positive.");
    }
    if (amount > this.balance) {
      throw new Error("Insufficient funds.");
    }
    this.balance -= amount;
    console.log(`Withdrawn $${amount}. New balance: $${this.balance}`);
  }

  getBalance(): number {
    return this.balance;
  }
}

class SpecialAccount extends BankAccount {
  withdraw(amount: number): void {
    if (amount > 0) {
      this.balance -= amount; // Allows overdraft (negative balance)
      console.log(`Withdrawn $${amount}. New balance: $${this.getBalance()}`);
    } else {
      console.log("Withdrawal amount must be positive.");
    }
  }
}

// Demonstration
const account = new BankAccount("12345", "José", 1000);
console.log(`Account ID: ${account.id}`);
console.log(`Customer Name: ${account.customerName}`);
account.customerName = "José Santos";
console.log(`Updated Customer Name: ${account.customerName}`);
account.deposit(500);
account.withdraw(200);
console.log(`Final balance: $${account.getBalance()}`);

try {
  account.withdraw(2000);
} catch (error) {
  console.error(`Error: ${(error as Error).message}`);
}

// Special Account Demonstration
const specialAccount = new SpecialAccount("67890", "Leila VIP", 500);
console.log(`Special Account ID: ${specialAccount.id}`);
console.log(`Customer Name: ${specialAccount.customerName}`);

specialAccount.deposit(300);
specialAccount.withdraw(1000); // Overdraft allowed
console.log(`Final balance: $${specialAccount.getBalance()}`);
