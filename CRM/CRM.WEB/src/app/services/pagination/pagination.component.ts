import { Component, Input, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
    selector: 'app-pagination',
    standalone: true,
    imports: [CommonModule],
    templateUrl: './pagination.component.html'
})
export class PaginationComponent implements OnChanges {

    readonly visiblePagesCount = 5;

    @Input() items: any[] = [];


    @Input() pageSize: number = 5;


    @Output() pageChange = new EventEmitter<any[]>();


    currentPage: number = 1;


    totalPages: number = 1;


    pages: number[] = [];

    /** Detect changes on inputs to recalculate pagination */
    ngOnChanges(changes: SimpleChanges): void {
        if (changes['items']) {
            // When the item list changes, reset to page 1 and recalc total pages
            this.currentPage = 1;
            this.totalPages = Math.ceil(this.items.length / this.pageSize) || 1;
            this.updatePage();
        }
        if (changes['pageSize']) {
            // If page size changes, recalc total pages and adjust current page if needed
            this.totalPages = Math.ceil(this.items.length / this.pageSize) || 1;
            if (this.currentPage > this.totalPages) {
                this.currentPage = this.totalPages;
            }
            this.updatePage();
        }
    }

    /** Helper method to update pagination data and emit current page items */
    private updatePage(): void {
        if (this.currentPage < 1) {
            this.currentPage = 1;
        }
        if (this.currentPage > this.totalPages) {
            this.currentPage = this.totalPages;
        }

        // Define a janela de páginas (ex: 5 páginas visíveis)
        let startPage = Math.max(1, this.currentPage - Math.floor(this.visiblePagesCount / 2));
        let endPage = startPage + this.visiblePagesCount - 1;

        if (endPage > this.totalPages) {
            endPage = this.totalPages;
            startPage = Math.max(1, endPage - this.visiblePagesCount + 1);
        }

        this.pages = Array.from({ length: endPage - startPage + 1 }, (_, i) => startPage + i);

        const startIndex = (this.currentPage - 1) * this.pageSize;
        const endIndex = startIndex + this.pageSize;
        const paginatedItems = this.items.slice(startIndex, endIndex);

        this.pageChange.emit(paginatedItems);
    }


    /** Navigate to a specific page (triggered by clicking a page number) */
    goToPage(page: number): void {
        if (page >= 1 && page <= this.totalPages) {
            this.currentPage = page;
            this.updatePage();
        }
    }

    /** Navigate to the next page (triggered by "Próxima" button) */
    nextPage(): void {
        if (this.currentPage < this.totalPages) {
            this.currentPage++;
            this.updatePage();
        }
    }

    /** Navigate to the previous page (triggered by "Anterior" button) */
    prevPage(): void {
        if (this.currentPage > 1) {
            this.currentPage--;
            this.updatePage();
        }
    }
}
