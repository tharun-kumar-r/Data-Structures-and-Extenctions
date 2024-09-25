export interface Employee {
    id: number;
    firstName: string;
    lastName: string;
    middleName?: string;  // Optional field
    contact: string;
    email: string;
    dateOfBirth: string;  // Using string for simplicity; consider Date type if needed
    address: string;
    gender: string;       // Male or Female
    password: string;     // For user authentication
    department: string;
    profilePicture?: string; // Optional field for profile picture
    termsAccepted:any;
}
