import {IPaginationData} from "../../shared/interfaces/IPaginationData"
import {IArtist} from "../../shared/interfaces/IArtist"

export class PerformersListing {
    performers: Array<IArtist>;
    paginationData: IPaginationData;

    constructor(performers: Array<IArtist>, paginationData: IPaginationData) {
        this.performers = performers;
        this.paginationData = paginationData;
    }
}