```markdown
# AGENTS.md File Guidelines

These guidelines are designed to ensure the quality, maintainability, and efficiency of all AGENTS.md files within this repository. Adherence to these principles is mandatory for all development efforts.

## 1. DRY (Don't Repeat Yourself)

*   **Single Responsibility Principle:** Each AGENT.md file should have a single, well-defined purpose.
*   **Code Reuse:** Identify and reuse common logic and data structures across multiple AGENT.md files.
*   **Abstraction:** Abstract complex logic into reusable components.
*   **Avoid Redundant Code:** Eliminate duplicated code snippets and functions.

## 2. KISS (Keep It Simple, Stupid)

*   **Simplicity:** Strive for the simplest possible solution that meets the requirements.
*   **Readability:** Prioritize code clarity and easy comprehension.
*   **Minimalism:** Reduce the amount of code required to achieve a task.

## 3. SOLID Principles

*   **Single Responsibility Principle:** AGENT.md files should have a single primary function.
*   **Open/Closed Principle:** AGENT.md files should be extensible without modifying their core code.  New functionality can be added via new files.
*   **Liskov Substitution Principle:**  Subclasses should be substitutable for their base classes without altering the correctness of the system.
*   **Interface Segregation Principle:** Each interface should have a minimal set of responsibilities.
*   **Dependency Inversion Principle:** High-level modules should not depend on low-level modules; they should depend on abstractions.

## 4. YAGNI (You Aren't Gonna Need It)

*   **Avoid Unnecessary Features:**  Implement only the necessary functionality for the current task.
*   **Future-Proofing:** Design for potential future requirements, but avoid adding features you don’t currently need.
*   **Progressive Complexity:** Introduce complexity incrementally, testing each step carefully.

## 5. Development Focus & Workflow

*   **Focus on Functionality:** The primary goal is to deliver a functional AGENT.md file that meets the specified requirements.
*   **Test-Driven Development:** All AGENT.md files must be thoroughly tested using provided mocks.
*   **Incremental Development:**  Build functionality incrementally, testing each phase of development.
*   **Code Reviews:** All new code must undergo a thorough review by at least one other developer.
*   **Documentation:**  Comments explaining the purpose, logic, and dependencies should be included.
*   **Error Handling:**  Implement proper error handling and logging.
*   **Version Control:**  Use Git for version control and adhere to established branching strategies.
*   **Code Style:** Follow a consistent code style guide (e.g., Google Style).
*   **Line Length:** Maximum 180 lines of code per file.
*   **Unit Testing:** All AGENT.md files should have a minimum of 80% unit test coverage.

## 6.  File Structure & Conventions

*   **Top-Level Directories:**  All AGENT.md files should reside in the `agents` directory.
*   **Naming Conventions:** Use descriptive names for AGENT.md files.
*   **Modularization:**  Organize code into logical modules and components.
*   **Data Structures:** Define clear data structures for AGENT.md files.
*   **Error Handling:** Implement basic error handling mechanisms.

## 7.  Testing

*   **Comprehensive Tests:**  All AGENT.md files should have a minimum of 80% test coverage based on automated testing.
*   **Test Case Design:**  Test cases should cover all critical scenarios.
*   **Test Suite:** Maintain a test suite to ensure code quality.

## 8.  Code Quality

*   **Readability:** Code should be easy to read and understand.
*   **Maintainability:**  Code should be easy to modify and maintain.
*   **Bug-Free:** Ensure the code is free of bugs and errors.

These guidelines are intended as a reference and may be subject to change as the project evolves.  Compliance with these principles is mandatory for all AGENTS.md files.
```