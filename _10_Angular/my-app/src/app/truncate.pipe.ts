import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'truncate',
  standalone: true
})
export class TruncatePipe implements PipeTransform {
  transform(value: string | null, limit: number = 20, ellipsis: string = '...'): string {
    if (!value) return '';
    return value.length <= limit ? value : value.substring(0, limit) + ellipsis;
  }
}