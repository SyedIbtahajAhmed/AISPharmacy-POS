import { AISPharmacyTemplatePage } from './app.po';

describe('AISPharmacy App', function() {
  let page: AISPharmacyTemplatePage;

  beforeEach(() => {
    page = new AISPharmacyTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
