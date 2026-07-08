/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
public static void Run() {
    // Test 1
    // Scenario: Add one customer, then serve them.
    // Expected Result: Displays the customer that was added.
    Console.WriteLine("Test 1");
    var service = new CustomerService(4);
    service.AddNewCustomer();
    service.ServeCustomer();
    // Defect(s) Found: ServeCustomer removed the customer before reading it.

    Console.WriteLine("=================");

    // Test 2
    // Scenario: Add two customers, serve them, check the order.
    // Expected Result: Served in the same order they were added (FIFO).
    Console.WriteLine("Test 2");
    service = new CustomerService(4);
    service.AddNewCustomer();
    service.AddNewCustomer();
    Console.WriteLine($"Before serving customers: {service}");
    service.ServeCustomer();
    service.ServeCustomer();
    Console.WriteLine($"After serving customers: {service}");
    // Defect(s) Found: None.

    Console.WriteLine("=================");

    // Test 3
    // Scenario: Serve a customer when the queue is empty.
    // Expected Result: An error message is displayed.
    Console.WriteLine("Test 3");
    service = new CustomerService(4);
    service.ServeCustomer();
    // Defect(s) Found: ServeCustomer did not check for an empty queue.

    Console.WriteLine("=================");

    // Test 4
    // Scenario: Add more customers than the max size (add 5 when max is 4).
    // Expected Result: An error message when the 5th is added.
    Console.WriteLine("Test 4");
    service = new CustomerService(4);
    service.AddNewCustomer();
    service.AddNewCustomer();
    service.AddNewCustomer();
    service.AddNewCustomer();
    service.AddNewCustomer();
    Console.WriteLine($"Service Queue: {service}");
    // Defect(s) Found: AddNewCustomer used > instead of >= for the full check.

    Console.WriteLine("=================");

    // Test 5
    // Scenario: Create the queue with an invalid size (0).
    // Expected Result: Size defaults to 10.
    Console.WriteLine("Test 5");
    service = new CustomerService(0);
    Console.WriteLine($"Size should be 10: {service}");
    // Defect(s) Found: None.
}
    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>

private void AddNewCustomer() {
    // Verify there is room in the service queue
    if (_queue.Count >= _maxSize) {          // Bug 3 fixed: >= not >
        Console.WriteLine("Maximum Number of Customers in Queue.");
        return;
    }

    Console.Write("Customer Name: ");
    var name = Console.ReadLine()!.Trim();
    Console.Write("Account Id: ");
    var accountId = Console.ReadLine()!.Trim();
    Console.Write("Problem: ");
    var problem = Console.ReadLine()!.Trim();

    var customer = new Customer(name, accountId, problem);
    _queue.Add(customer);
}

private void ServeCustomer() {
    if (_queue.Count <= 0) {                 // Bug 2 fixed: check for empty first
        Console.WriteLine("No Customers in the queue");
    }
    else {
        var customer = _queue[0];            // Bug 1 fixed: read before removing
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }
}
    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}