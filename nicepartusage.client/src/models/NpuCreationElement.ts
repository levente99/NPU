import { NpuCreation, Element } from '.';

export interface NpuCreationElement {
    id: number;
    npuCreationId: number;
    elementId: number;
    npuCreation: NpuCreation;
    element: Element;
}
