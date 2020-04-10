import { Role } from "./role";

export class User {
    id: string;
    userName: string;
    password: string;
    firstName: string;
    lastName: string;
    role: Role;
    token?: string;
};