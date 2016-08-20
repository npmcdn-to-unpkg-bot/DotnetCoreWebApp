import { EventEmitter, ChangeDetectorRef } from 'angular2/core';
import { PaginationService } from "./pagination-service";
export interface IPage {
    label: string;
    value: any;
}
export declare class PaginationControlsCmp {
    private service;
    private changeDetectorRef;
    id: string;
    maxSize: number;
    directionLinks: boolean;
    autoHide: boolean;
    pageChange: EventEmitter<number>;
    template: any;
    pages: IPage[];
    private hasTemplate;
    private changeSub;
    private _directionLinks;
    private _autoHide;
    constructor(service: PaginationService, changeDetectorRef: ChangeDetectorRef);
    ngOnInit(): void;
    ngOnChanges(): void;
    ngAfterViewInit(): void;
    ngOnDestroy(): void;
    /**
     * Go to the previous page
     */
    previous(): void;
    /**
     * Go to the next page
     */
    next(): void;
    /**
     * Returns true if current page is first page
     */
    isFirstPage(): boolean;
    /**
     * Returns true if current page is last page
     */
    isLastPage(): boolean;
    /**
     * Set the current page number.
     */
    setCurrent(page: number): void;
    /**
     * Get the current page number.
     */
    getCurrent(): number;
    /**
     * Returns the last page number
     */
    getLastPage(): number;
    /**
     * Updates the page links and checks that the current page is valid. Should run whenever the
     * PaginationService.change stream emits a value matching the current ID, or when any of the
     * input values changes.
     */
    private updatePageLinks();
    /**
     * Checks that the instance.currentPage property is within bounds for the current page range.
     * If not, return a correct value for currentPage, or the current value if OK.
     */
    private outOfBoundCorrection(instance);
    /**
     * Returns an array of IPage objects to use in the pagination controls.
     */
    private createPageArray(currentPage, itemsPerPage, totalItems, paginationRange);
    /**
     * Given the position in the sequence of pagination links [i],
     * figure out what page number corresponds to that position.
     */
    private calculatePageNumber(i, currentPage, paginationRange, totalPages);
}
