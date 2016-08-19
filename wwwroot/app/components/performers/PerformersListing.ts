import {PaginationData} from "../../shared/models/PaginationData"
import {Artist} from "../../shared/models/Artist"

export class PerformersListing {
    performers: Array<Artist>;
    paginationData: PaginationData;

    constructor(performers: Array<Artist>, paginationData: PaginationData) {
        this.performers = performers;
        this.paginationData = paginationData;
    }
}