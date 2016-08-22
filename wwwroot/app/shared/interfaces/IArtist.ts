export interface IArtist {
    artistId: number;
    name: string;
    album: Array<any>;
    guid: string;
    dateCreated: string;
    dateModifed: string;
    objectState: string;
    rowVersion: string;
    deleted: boolean;

}