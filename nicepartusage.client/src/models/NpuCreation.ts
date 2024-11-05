import { Element, NpuCreationElement, Score, User } from '.';

export interface NpuCreation {
    id: number;
    elements: Element[];
    title: string;
    description: string;
    fileData: string;
    uploadDate: string;
    creator: User;
    scores: Score[];
    npuCreationElements: NpuCreationElement[];
}