import { NpuCreation, Score } from '.';

export interface User {
    id: number;
    userName: string;
    firstName: string;
    lastName: string;
    dateJoined: string;
    creations: NpuCreation[];
    scores: Score[];
}