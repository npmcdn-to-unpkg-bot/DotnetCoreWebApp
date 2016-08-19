export class PaginationData {

    constructor(){}
    offsetFromZero: number;
    pageNumber: number;
    pageSize: number;
    offsetUpperBound: number;
    totalNumberOfRecords: number;
    totalNumberOfPages: number;
    searchTermsCommaSeparated: string;
    sortColumn: string;
    sortDirection: string
}