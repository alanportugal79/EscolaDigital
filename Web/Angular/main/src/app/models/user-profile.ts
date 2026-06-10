export interface UserProfile {
    id : string;
    username : string;
    name : string;
    email : string;
    firstName : string;
    lastName : string;
    enabled : boolean;
    emailVerified : boolean;
    totp : boolean;
}