import {IWebsites} from './websites';

export interface IPreferences {
    minPrice: number;
    maxPrice: number;
    websites: IWebsites[];
}
