export interface ResponseResult<T> {
    data: T[];
    recordCount: number;
    totalPage: number;
    currentPage: number;
    recordPerPage: number;
}