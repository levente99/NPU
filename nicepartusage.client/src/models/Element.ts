import { NpuCreation, NpuCreationElement } from '.';

export interface Element {
    id: number;
    name: string;
    description: string;
    npuCreations: NpuCreation[];
    npuCreationElements: NpuCreationElement[];
}