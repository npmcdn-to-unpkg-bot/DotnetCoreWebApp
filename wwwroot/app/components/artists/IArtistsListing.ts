import {IPaginationData} from "../../shared/interfaces/IPaginationData"
import {IArtist} from "../../shared/interfaces/IArtist"

export interface IArtistsListing {
    paginationData: IPaginationData;
    performers: IArtist[];

}